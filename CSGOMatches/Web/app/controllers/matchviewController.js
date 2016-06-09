angular.module("Home")
    .controller("matchviewController",
        function ($scope, $location, $routeParams, matchesService, commentService) {
            console.log("MatchviewController init");

            console.log($routeParams.id);

            //var loadComments = function () {
            //    commentService.getComments($routeParams.id).then(function (resp) {
            //        $scope.comments = resp.data;
            //        console.log(resp.data);
            //    });
            //}

            matchesService.getMatch($routeParams.id)
                .then(function (resp) {
                    $scope.match = resp.data;
                    console.log(resp.data);
                });

            var loadComments = function() {
                commentService.getComments($routeParams.id).then(function (resp) {
                    $scope.comments = resp.data;
                    console.log(resp.data);
                });
            }

            $scope.addComment = function() {
                var comment = {
                    Name: $scope.commentName,
                    CommentText: $scope.commentText,
                    MatchId: $routeParams.id
                };

                commentService.addComment(comment).success(function () {
                    loadComments();
                });
            };

            $scope.deleteMatch = function() {
                matchesService.deleteMatch($routeParams.id);
                $location.path("/");
            }

            $scope.removeComment = function(id) {
                commentService.deleteComment(id).success(function() {
                    loadComments();
                });
                
            }

            loadComments();

        });