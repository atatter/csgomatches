angular.module("Home")
    .controller("addeditteamController",
        function ($scope, $location , $routeParams , playersService , teamsService) {
            console.log("AddEditTeamController init");
            if (!$scope.auth) {
                $location.path("/");
            }
            var loadPlayers = function() {
                playersService.getPlayers().success(function(e) {
                    $scope.players = e;
                    console.log(e);

                });
            }

            if ($routeParams.j == "e" && $routeParams.id != undefined) {
                $scope.e = true;
                $scope.c = false;
                teamsService.getTeamById($routeParams.id).success(function(e) {
                    $scope.teamName = e.name;
                    $scope.playersInTeam = e.playerIds;
                    console.log("Test Area: " + $scope.playersInTeam);
                });
            } else if ($routeParams.j == "c") {
                $scope.e = false;
                $scope.c = true;
            } else {
                $location.path("/teams");
            }

            $scope.addTeam = function () {
                var teaminfo = {
                    Name: $scope.teamName,
                    PlayerIds: $scope.playersInTeam
                }
                console.log("TeamName: " + $scope.TeamName + ", TeamPlayerIds: " +  $scope.Players);
                teamsService.addTeam(teaminfo).success(function() {
                    $location.path("/teams");
                });
            }

            $scope.editTeam = function () {
                var teaminfo = {
                    Name: $scope.teamName,
                    PlayerIds: $scope.playersInTeam
                }
                teamsService.editTeam(teaminfo, $routeParams.id).success(function () {
                    $location.path("/teams");
                });
            }

            loadPlayers();

        });