# import the New Relic Python Agent
import newrelic.agent
import os
from flask import Flask, render_template, request
import markdown
from openai import OpenAI

# initialize the New Relic Python agent
newrelic.agent.initialize('newrelic.ini')

#endpoint = os.environ["ENDPOINT"]
#api_key = os.environ["API_KEY"]
model_name = os.environ["MODEL"]

#client = OpenAI(
#    #api_version="2024-11-20",
#    #azure_endpoint=endpoint,
#    api_key=api_key
#)
client = OpenAI(
    base_url="https://models.inference.ai.azure.com",
    api_key=os.environ["GITHUB_TOKEN"],
)

app = Flask(__name__)

def chatCompletion(prompt):
    #prompt = "who are you?"
    print (f"Prompt: {prompt}")
        
    completion = client.chat.completions.create(
        model=model_name,
        messages=[
            {"role": "user", "content": prompt}
        ])
    content = completion.choices[0].message.content
    content = content.replace("\n", "</p><br />")
    return content

@app.route("/")
def home():
    return render_template("index.html")

@newrelic.agent.background_task()
@app.route("/prompt", methods=["POST"])
def prompt():
    input_prompt = request.json.get("prompt")
    output_prompt = chatCompletion(input_prompt)
    html_output = markdown.markdown(output_prompt)
    output_prompt = html_output.replace("<p>", "").replace("</p>", "")
    return output_prompt

application = newrelic.agent.register_application(
    timeout=5)  # force New Relic agent registration

# make the server publicly available via port 5004
# flask --app levelsix.py run --host 0.0.0.0 --port 5004
if __name__ == '__main__':
    app.run(host="0.0.0.0", debug=True, port=5004)

newrelic.agent.shutdown_agent(timeout=2.5)  # shutdown New Relic agent
