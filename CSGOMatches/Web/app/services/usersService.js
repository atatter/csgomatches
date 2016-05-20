angular.module("Authentication")
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
                console.log("LOGINSTUFF - Username: " + userinfo.username + " Password: " + userinfo.password);
                return $http({
                    method: 'POST',
                    url: 'http://localhost:10742/Token',
                    data: "grant_type=" + userinfo.grant_type + "&username=" + userinfo.username + "&password=" + userinfo.password
                });
            }

            usersAPI.isAuth = function() {
                var token = sessionStorage.getItem('accessToken');
                var headers = {};

                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                $http({
                        type: 'GET',
                        url: 'http://localhost:10742/api/Account/UserInfo',
                        headers: headers
                    }).then(function successCallback(response) {
                            console.log("has auth");
                            return true;
                        },
                        function errorCallback(response) {
                            console.log("no auth");
                            return false;
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