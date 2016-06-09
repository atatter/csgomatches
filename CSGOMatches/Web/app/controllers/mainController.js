angular.module("Home")
    .controller("mainController",
        function ($scope, usersService) {

            console.log("MainController started");

            $scope.auth = false;

            usersService.getUserInfo().then(function successCallback(response) {
                $scope.auth = true;
                console.log("Current auth: " + $scope.auth);
            });

            //usersService.getUserInfo().success(function() {
            //    $scope.auth = true;
            //    $scope.$apply();
            //});

            $scope.printAuth = function() {
                console.log("Current auth: " + $scope.auth);
            };

            $scope.logout = function() {
                sessionStorage.removeItem('accessToken');
                $scope.auth = false;
            }
            $scope.trueAuth = function () {
                $scope.auth = true;
            }

        });