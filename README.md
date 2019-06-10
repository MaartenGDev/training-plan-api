# TrainingPlan
Application to demo database created for ISE project

## Setup
1. Open `Web` project
2. Copy appsettings.json to appsettings.Development.json
3. Change the connection string to your local mysql instance

### Database
1. Navigate to `DataContext` folder.
1. Run: `dotnet ef database update -s ../Web`
