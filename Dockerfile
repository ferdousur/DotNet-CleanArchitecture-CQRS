#State - 1

FROM mcr.microsoft.com/dotnet/sdk:10.0 as Build 

#setup directory for container (na thakle banau)
WORKDIR  /app 

#copy all dependency to app
COPY *.csproj . 

# all dependency restore 
RUN dotnet restore

#copy all code

COPY . .

#publish kore container er app/publish a rakho
RUN dotnet publish -c Release -o /publish

#Stage - 2
FROM mcr.microsoft.com/dotnet/aspnet:10.0 
#ache use koro 
WORKDIR  /app
#copy from state 1 er build (ja publish a ache) and past on current directory 
COPY --from=Build /publish .

#run whole applicaiton from container
ENTRYPOINT ["dotnet", "CleanMediator.dll"]


