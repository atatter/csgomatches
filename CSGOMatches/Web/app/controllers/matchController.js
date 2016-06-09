angular.module("Home")
    .controller("matchController",
        function ($scope, usersService, teamsService, matchesService) {
            if (!$scope.auth) {
                $location.path("/");
            }
            console.log("MatchController init");
            $scope.match = {
                TeamOneId: 0,
                TeamTwoId: 0,
                Maps: []
            };

            teamsService.getTeams().then(function(resp) {
                $scope.teams = resp.data;
                console.log($scope.teams);
            });

            matchesService.getMaps().then(function (resp) {
                $scope.maps = resp.data;
                console.log($scope.maps);
            });
            //teamsService.getTeams()
            //    .success(function (resp) {
            //        $scope.teams = resp;
            //    });


            $scope.addMatch = function () {
                var matchinfo = {
                    TeamOneId: $scope.TeamOneId,
                    TeamTwoId: $scope.TeamTwoId,
                    MapIds: $scope.Maps
                }
                matchesService.addMatch(matchinfo);
                console.log("Team One Id: " + $scope.TeamOneId + " Team Two Id: " + $scope.TeamTwoId + " Maps:" + $scope.Maps);
            }

        });