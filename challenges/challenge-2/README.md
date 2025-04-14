# Challenge 2

In this challenge we will export all the telemetry from our sample application into New Relic as our observability backend.

Follow the steps below:

1. Open the `Terminal` tab in the bottom panel

2. Change folder into `challenge-1` folder

    ```bash
    cd ../challenge-2
    ```

3. In the `Explorer` on the lft side, open [challenges/challenge-2/app.AppHost/Program.cs](app.AppHost/Program.cs)

## .NET Aspire orchestration overview

.NET Aspire provides APIs for expressing resources and dependencies within your distributed application (please find more information [here](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/app-host-overview)).

In our sample application, we first create a distributed application builder. We then add our two projects as references to the application builder. As you can see, we can also express dependencies between these services as you can see in the webfrontend reference.
