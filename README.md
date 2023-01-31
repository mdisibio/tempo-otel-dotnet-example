# Instrumenting a web api with .Net and OpenTelemetry
This repo contains the sample code and files for the blog post [here](https://grafana.com/blog/2021/02/11/instrumenting-a-.net-web-api-using-opentelemetry-tempo-and-grafana-cloud/).  It shows how to use the [OpenTelemetry.NET libraries](https://github.com/open-telemetry/opentelemetry-dotnet) to capture traces for incoming http requests, and use the [Grafana Agent](https://github.com/grafana/agent) to forward them Grafana Cloud Tempo.

## Usage
1. Edit `agent.yaml` and supply your Grafana Cloud user name and api keys for Tempo.  
1. Start the agent and the example app for the .NET framework you are interested in. `docker-compose up dotnet6 agent`
1. Generate some requests `curl http://localhost:5000/weather` (this works for all examples)
1. Browse to `https://<your_stack>.grafana.net` and explore the traces.
    1. Click on the Search tab and then Run query. By default it will show traces received in the last hour.
    1. Try looking up a trace by ID.  Each example logs the message `"Getting weather forecast traceID=<ID>"`.  Copy and paste this ID into the `TraceID` tab and then Run query to view the specific trace.


