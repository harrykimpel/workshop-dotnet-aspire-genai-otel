# Challenge 1

In this initial challenge we will first get the .NET Aspire sample application up and running.

Follow the steps below to run the sample application:

1. Open the `Terminal` tab in the bottom panel

2. Change folder into `challenge-1` folder

    ```bash
    cd challenges/challenge-1
    ```

3. Run the sample application

    ```bash
    dotnet run --project app.AppHost/app.AppHost.csproj
    ```

Once the application is ready, you should see some output like this.

![.NET Aspire terminal output](./assets/dotnet-run-aspire-terminal-output.png)

In order to get to the .NET Aspire developer dashboard, click into your `Login to the dashboard at ...` link.

![.NET Aspire dashboard link](./assets/dotnet-run-aspire-dashboard-link.png)

The .NET Aspire dashboard then shows you an overview of all the resources involved in the sample aplication.

![.NET Aspire resources](./assets/dotnet-aspire-dashboard-resources.png)

Clicking on the URL for the `webfrontend`, brings you into the actual web frontend of our sample application.

![Web Frontend](./assets/web-frontend.png)

Play around with the app and familiarize yourself with the user interface and all of its components. I encourage you to navigate to the `Counter` and `Weather` components.

## .NET Aspire developer dashboard

Back in the .NET Aspire developer dashboard, we can then explore other areas of this dashboard:

- Console logs

    ![.NET Aspire dashboard console logs](./assets/dotnet-aspire-dashboard-console-logs.png)

- Structured logs

    ![.NET Aspire dashboard structured logs](./assets/dotnet-aspire-dashboard-structured-logs.png)

- Traces

    ![.NET Aspire dashboard traces](./assets/dotnet-aspire-dashboard-traces.png)

- Metrics

    ![.NET Aspire dashboard metrics](./assets/dotnet-aspire-dashboard-metrics.png)
