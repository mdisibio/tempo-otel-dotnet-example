# Instrumenting a web api with .Net, Tempo, and OpenTelemetry
This repo contains the sample code and files for the blog post [here](https://grafana.com/blog/2021/02/11/instrumenting-a-.net-web-api-using-opentelemetry-tempo-and-grafana-cloud/).  It shows how to use the [OpenTelemetry.NET libraries](https://github.com/open-telemetry/opentelemetry-dotnet) to captures traces for incoming http requests, and use the [Grafana Agent](https://github.com/grafana/agent) to forward them Grafana Cloud Tempo.

## Usage
1. Edit agent-config.yaml and docker-compose.yaml with your Grafana Cloud user name and api keys for Tempo and Loki.  
1. Run `docker-compose up`.  Browse to [http://localhost:5000/swagger](http://localhost:5000/swagger) and make some requests.  
1. Browse to <your_stack>.grafana.net and explore the logs and traces.
