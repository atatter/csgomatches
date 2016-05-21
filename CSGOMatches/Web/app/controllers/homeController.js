angular.module("Home")
    .controller("homeController",
        function ($scope, usersService) {



            console.log("HomeController initialized");

            var userinfo = {
                Email: "alekstattesr@gmail.com",
                Password: "kammajaa",
                ConfirmPassword: "kammajaa"
            };

            var logininfo = {
                grant_type: 'password',
                username: "alekstatter@gmail.com",
                password: "kammajaa"
            };

            //usersService.registerUser(userinfo)
            //    .then(function(resp) {
            //        console.log("Response message: " + resp);
            //    });

            //usersService.getAuth(logininfo).success(function(resp) {
            //    console.log(resp.userName);
            //    sessionStorage.setItem('accessToken', resp.access_token);
            //});

           
                usersService.getUserInfo().then(function (resp) {

                $scope.user = resp.data.email;

                });

            $scope.logout = function () {
                sessionStorage.removeItem('accessToken');
            }

        });