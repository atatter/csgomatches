angular.module("Authentication")
    .controller("loginlogoutController",
        function ($scope, usersService) {

            console.log("LoginLogoutController initialized");


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
                });
            }

            
            
        });