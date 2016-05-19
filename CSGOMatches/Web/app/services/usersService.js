angular.module("matchesapp.services", [])
    .factory("usersService",
        function ($http) {
            console.log("UsersService initialized");

            var usersAPI = {};

            usersAPI.registerUser = function(userinfo) {
                return $http({
                    method: 'POST',
                    url: 'http://localhost:10742/api/Account/Register',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8'
                    },
                    data: userinfo
                });
            }

            usersAPI.getAuth = function (userinfo) {

                return $http({
                    method: 'POST',
                    url: 'http://localhost:10742/Token',
                    data: "grant_type=" + userinfo.grant_type + "&username=" + userinfo.username + "&password=" + userinfo.password
                });
            }

            usersAPI.getUserInfo = function() {

                var token = sessionStorage.getItem('accessToken');
                var headers = {};

                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                return $http({
                    type: 'GET',
                    url: 'http://localhost:10742/api/Account/UserInfo',
                    headers: headers
                });

            }

            usersAPI.getValues = function () {

                var token = sessionStorage.getItem('accessToken');
                var headers = {};

                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                return $http({
                    type: 'GET',
                    url: 'http://localhost:10742/api/values',
                    headers: headers
                });

            }

            return usersAPI;
        });