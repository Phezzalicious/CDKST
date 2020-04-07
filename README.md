# CDKSTExample

Make a new folder somewhere   
git init  
git add remote phelpsIsCool https://github.com/Phezzalicious/CDKSTExample.git  
git pull phelpsIsCool master  
cd MyData  
dotnet ef migrations add InitialCreate --startup-project ../CDKST/CDKST.csproj --context CDKSTContext  
cd ..  
cd CDKST  
dotnet ef database update --context CDKSTContext  
dotnet run  
go to localhost:5000  
scroll down and click the dispositions button  
that is seeded data

Sorry about the bad style and such, Work in progress  
