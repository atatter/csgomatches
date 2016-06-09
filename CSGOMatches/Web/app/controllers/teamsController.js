angular.module("Home")
    .controller("teamsController",
        function ($scope, $location, teamsService) {
            console.log("TeamsController init");

            var loadTeams = function() {
                teamsService.getTeams().success(function(resp) {
                    $scope.teams = resp;
                    console.log(resp);
                });
            }


            $scope.deleteTeam = function (id) {
                teamsService.deleteTeam(id).success(function () {
                    loadTeams();
                });
            }

            $scope.editTeam = function(id) {
                $location.path("/#/addeditteam?j=e&id=" + id);
            }

            loadTeams();

        });