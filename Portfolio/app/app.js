(function () {
    "use strict";

    var app = angular.module("portfolio",
                                [
                                    "ngAnimate",
                                    "common.services",
                                    "ui.router",
                                    "ui.bootstrap"
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
                    .state("portfolio", {
                        url: "/portfolio",
                        templateUrl: "app/project/projectListView.html",
                        controller: "projectListController as vm"
                    })

                    .state("newProject", {
                        abstract: true,
                        url: "/newproject",
                        templateUrl: "app/project/newProjectView.html",
                        controller: "newProjectController as vm"
                    })
                    .state("newProject.basicInfo", {
                        url: "/basicinfo",
                        templateUrl: "app/project/newProjectBasicInfoView.html",
                    })
                    .state("newProject.uploads", {
                        url: "/uploads",
                        templateUrl: "app/project/newProjectUploadsView.html",
                    })
                    .state("newProject.otherDetails", {
                        url: "/otherdetails",
                        templateUrl: "app/project/newProjectOtherDetailsView.html",
                    })

                    .state("projectDetail", {
                        url: "/project/:projectId",
                        templateUrl: "app/project/projectDetailView.html",
                        controller: "projectDetailController as vm",
                        resolve: {
                            projectResource: "projectResource",

                            project: function (projectResource, $stateParams) {
                                var projectId = $stateParams.projectId;
                                return projectResource.get({ projectId: projectId }).$promise;
                            }
                        }
                    })
                    .state("projectEdit", {
                        url: "/edit/:projectId",
                        templateUrl: "app/project/projectEditView.html",
                        controller: "projectEditController as vm",
                        resolve: {
                            projectResource: "projectResource",

                            project: function (projectResource, $stateParams) {
                                var projectId = $stateParams.projectId;
                                return projectResource.get({ projectId: projectId }).$promise;
                            }
                        }
                    });
                    //.state("projectEdit.basicInfo", {
                    //    url: "/basicinfo",
                    //    templateUrl: "app/project/projectEditBasicInfoView.html",
                    //})
                    //.state("projectEdit.uploads", {
                    //    url: "/uploads",
                    //    templateUrl: "app/project/projectEditUploadsView.html",
                    //})
                    //.state("projectEdit.otherDetails", {
                    //    url: "/otherdetails",
                    //    templateUrl: "app/project/projectEditOtherDetailsView.html",
                    //});
            }
        ]
    );

})();

