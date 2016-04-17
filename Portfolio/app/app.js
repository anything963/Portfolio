(function () {
    "use strict";

    var app = angular.module("portfolio",
                                [
                                    "ngAnimate",
                                    "common.services",
                                    "ui.router"
                                ]);

    app.config(
        [
            "$stateProvider", "$urlRouterProvider",
            function ($stateProvider, $urlRouterProvider) {
                $urlRouterProvider.otherwise("/");
                $stateProvider
                    .state("home", {
                        url: "/",
                        templateUrl: "app/project/projectListView.html",
                        controller: "projectListController as vm"
                    })
                    .state("portfolio",{
                        url: "/portfolio",
                        templateUrl: "app/project/projectListView.html",
                        controller: "projectListController as vm"
                    })
                    .state("newProject", {
                        url: "/newproject",
                        templateUrl: "app/project/newProjectView.html",
                        controller: "newProjectController as vm"
                    })
                    .state("projectDetail", {
                        url: "/project/:projectId",
                        templateUrl: "app/project/projectDetailView.html",
                        controller: "projectDetailController as vm"
                    })
                    .state("projectEdit", {
                        url: "/project/:projectId",
                        templateUrl: "app/project/projectEditView.html",
                        controller: "projectEditController as vm"
                    });
            }
        ]
    );

})();

