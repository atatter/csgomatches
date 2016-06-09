
angular.module('Authentication', []);
angular.module('Home', []);

angular.module('app',
    [
        'Authentication',
        'Home',
        'ngRoute'
    ])
    .config([
        '$routeProvider', function($routeProvider) {

            $routeProvider
                .when('/login',
                {
                    controller: 'loginController',
                    templateUrl: 'app/views/login.html'
                })
                .when('/logout',
                {
                    controller: 'logoutController',
                    templateUrl: 'app/views/logout.html'
                })
                .when('/addmatch',
                {
                    controller: 'matchController',
                    templateUrl: 'app/views/addmatch.html'
                }).when('/matchview',
                {
                    controller: 'matchviewController',
                    templateUrl: 'app/views/matchview.html'
                }).when('/teams',
                {
                    controller: 'teamsController',
                    templateUrl: 'app/views/teams.html'
                }).when('/players',
                {
                    controller: 'playersController',
                    templateUrl: 'app/views/players.html'
                }).when('/addeditteam',
                {
                    controller: 'addeditteamController',
                    templateUrl: 'app/views/teamAddEdit.html'
                }).when('/',
                {
                    controller: 'homeController',
                    templateUrl: 'app/views/home.html'
                })
                .otherwise({ redirectTo: '/' }
                );

        }
    ]);
