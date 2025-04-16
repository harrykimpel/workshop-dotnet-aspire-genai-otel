# Challenge 6

This specific "challenge" it not necessarily a challenge itself, but provides some informational aspects of the current capabilities of OpenTelemetry with monitoring AI/LLM applications.

## LLM Monitoring with OpenTelemetry using OpenLIT

[OpenLIT](https://github.com/openlit/openlit) is an OpenTelemetry-based library designed to streamline the monitoring of LLM-based applications by offering auto-instrumentation for a variety of Large Language Models and VectorDBs.

It aligns with the GenAI semantic conventions established by the OpenTelemetry community and ensures a smooth integration process by not relying on vendor-specific span or event attributes or environment variables for OTLP endpoint configuration, offering a standard solution.

## LLM Monitoring with OpenTelemetry using OpenLLMetry

[OpenLLMetry](https://www.traceloop.com/openllmetry) is a set of extensions built on top of [OpenTelemetry](https://opentelemetry.io/) that gives you complete observability over your LLM application. Because it uses OpenTelemetry under the hood, [it can be connected to your existing observability solutions](https://www.traceloop.com/docs/openllmetry/integrations/introduction) like [New Relic](https://www.traceloop.com/docs/openllmetry/integrations/newrelic).

It's built and maintained by Traceloop under the Apache 2.0 license.

The repo contains standard OpenTelemetry instrumentations for LLM providers and Vector DBs, as well as a Traceloop SDK that makes it easy to get started with OpenLLMetry, while still outputting standard OpenTelemetry data that can be connected to your observability stack. If you already have OpenTelemetry instrumented, you can just add any of our instrumentations directly.

## Other OpenTelemetry projects focusing on generative AI

There are many other generative AI focused observability projects out there such as:

- [Arize Phoenix](https://docs.arize.com/phoenix)
- [Langfuse](https://langfuse.com/)
- [LangSmith](https://www.langchain.com/langsmith)
- [Langtrace](https://langtrace.ai/)

Some of these projects are based on OpenTelemetry, others are "inspired by" it, but don't have out-of-the-box integration with OpenTelemetry.

The scope of generative AI observability includes instrumentations of various generative AI clients, frameworks, response evaluations, as well as model (server-side) instrumentations.

## Conclusion

OpenTelemetry in the industry is a game changer. An open standard like this enables, empowers and improves many challenges that we faced in the space of software development and DevOps/SRE in general.

Generative AI monitoring in the context of OpenTelemetry is not yet standardized, but given the history of OpenTelemetry, we can be very optimistic that this aspect of observing our applications will also soon to be standarized.

## Finally

After completing this last section, you successfully finished the workshop. Congratulations!
