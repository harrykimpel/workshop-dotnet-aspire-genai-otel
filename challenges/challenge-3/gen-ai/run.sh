NEW_RELIC_CONFIG_FILE=newrelic.ini newrelic-admin run-program flask --app app.py run --host 0.0.0.0 --port 5004

#export OTEL_PYTHON_LOGGING_AUTO_INSTRUMENTATION_ENABLED=true
#opentelemetry-instrument \
#    --traces_exporter otlp \
#    --metrics_exporter otlp \
#    --logs_exporter otlp \
#    python3 app.py