# build troubleshooting

Increase the build log verbosity in [Visual Studio to diagnostics](https://docs.microsoft.com/en-us/visualstudio/msbuild/obtaining-build-logs-with-msbuild?view=vs-2019). 

Head to Tools -> Options -> MS Build Verbosity

- Change to detailed (window/console logger)
- Change to detailed (log)

Quit visual studio and ensure that all processes have been terminated.

```bash
taskkill /fi "imagename eq devenv.exe" /f /t
taskkill /fi "imagename eq msbuild.exe" /f /t
taskkill /fi "imagename eq Uno.SourceGeneration.Host.exe" /f /t
```

Reset the source generation cache, your nuget cache and all local changes to your git repository. Be careful, as this will wipe out code you haven't yet commited.

```bash
git reset --hard
git clean -fdx
git checkout master
git pull origin master
```

Open the solution again and wait for background tasks (bottom left blue corner) to be {} aka None aka Ready.

Compile the `Uno UI -> Uno.UI` project.

If that doesn't work, try the following.

```
cd src
msbuild Uno.UI.sln /m /r /bl:restore.binlog /t:restore
msbuild Uno.UI.sln /m /r /bl:build.binlog
nuget locals all -clear
```

Then privately share the binlog. Please note that binlogs can contain sensitive information such as environment variables, thus if `ARM_CLIENT_SECRET` or `AWS_IAM_SECRET` or `MY_SUPER_SECRET_GITHUB_TOKEN` are set then they will be inside the logs and anyone with the logs can view em. Be careful.
