angular.module("matchesapp.services", [])
    .factory("valuesService",
        function() {

            var valuesAPI = {};

            valuesAPI.getValues = function () {

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

            return valuesAPI;

        });