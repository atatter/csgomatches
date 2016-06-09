angular.module("Authentication")
    .controller("loginController",
        function ($scope, $location, usersService) {

            console.log("LoginController initialized");


            //usersService.registerUser(userinfo)
            //    .then(function(resp) {
            //        console.log("Response message: " + resp);
            //    });

            $scope.login = function () {

                var logininfo = {
                    grant_type: 'password',
                    username: $scope.username,
                    password: $scope.password
                };

                usersService.getAuth(logininfo).success(function (resp) {
                    console.log(resp.userName);
                    sessionStorage.setItem('accessToken', resp.access_token);
                    $scope.trueAuth();
                    $location.path("/");
                });
            }

            
            
        });