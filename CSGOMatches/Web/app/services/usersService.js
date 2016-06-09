angular.module("Authentication")
    .factory("usersService",
        function ($http, baseService) {

            var usersAPI = {};

            usersAPI.registerUser = function (userinfo) {
                return baseService.post('api/Account/Register', userinfo);
            }

            usersAPI.getAuth = function (userinfo) {
                return baseService.post('Token', "grant_type=" + userinfo.grant_type + "&username=" + userinfo.username + "&password=" + userinfo.password);
            }


            usersAPI.isAuth = function () {
                var state;
                baseService.get('api/Account/UserInfo').success(function (data){
                        console.log("has auth");
                        state = true;
                    })
                .error(function (error, status){
                        console.log("no auth");
                        state = false;
                    });
                return state;
            }

            usersAPI.getUserInfo = function() {
                return baseService.get('api/Account/UserInfo');
            }

            usersAPI.getValues = function () {
                return baseService.get('api/values');
            }

            return usersAPI;
        });