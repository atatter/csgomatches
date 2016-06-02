angular.module("Home")
    .controller("matchviewController",
        function ($scope, $routeParams, matchesService, $location) {
            console.log("MatchviewController init");

            console.log($routeParams.id);

            matchesService.getMatch($routeParams.id)
                .then(function (resp) {
                    $scope.match = resp.data;
                    console.log(resp.data);
                });
            

            
        });