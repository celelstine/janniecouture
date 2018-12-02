# janniecouture


[![Build Status](https://travis-ci.org/celelstine/janniecouture.svg?branch=develop)](https://travis-ci.org/celelstine/janniecouture)

Jannie couture creates and delivers smart outfit as well as render other fashion services

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### prerequisites
To install this project you need the following framework and tools
```
- .NET Core 2.0.0
- Postgres
- Nodejs version >=8.0
```
### Installing
These Steps would help you install the project dependent packages. Every command that is listed below should be run on the root directory of the project (`jannieCouture/jannieCouture`)
- create a file called `appSettings.json`  
- copy the content of the file `appSettings.Development.json` to `appSettings.json`, then change the values to real values 
- install node modules; run `npm install ` 
- restore .net core project; run `dotnet install`
- migrate the database; run `dotnet ef database update`
- run the project; run `dotnet run`
- On success, the app should start on port 5001 or the port that you specified

### Running Test
Presently, we do not have test and we hope to add test in the nearest future

### Coding Style
we use airbnb and es6 for the Javascript section and dotnet standard for C# section

### Built With
- [.net core](https://github.com/dotnet/core)
- [Vue](https://vuejs.org/)
- [Postgres](https://www.postgresql.org/)

### Contributing
## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

[* **Okoro celestine**](https://github.com/celelstine)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
