
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
                .when('/',
                {
                    controller: 'homeController',
                    templateUrl: 'app/views/home.html'
                })
                .otherwise({ redirectTo: '/' });

        }
    ]);
