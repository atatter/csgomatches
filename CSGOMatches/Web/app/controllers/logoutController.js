angular.module("Authentication")
    .controller("logoutController",
        function ($scope, $route, $location, usersService) {

            console.log("LogoutController initialized");

            var logout = function() {
                console.log("Logging out");
                sessionStorage.removeItem('accessToken');
                $scope.auth = false;
                $location.path("/");
            }

            logout();
            $route.reload();
        });