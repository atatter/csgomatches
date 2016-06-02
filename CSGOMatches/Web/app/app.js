
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
                    controller: 'loginlogoutController',
                    templateUrl: 'app/views/login.html'
                })
                .when('/addmatch',
                {
                    controller: 'matchController',
                    templateUrl: 'app/views/addmatch.html'
                }).when('/matchview',
                {
                    controller: 'matchviewController',
                    templateUrl: 'app/views/matchview.html'
                })
                .when('/',
                {
                    controller: 'homeController',
                    templateUrl: 'app/views/home.html'
                })
                .otherwise({ redirectTo: '/' }
                );

        }
    ]);
