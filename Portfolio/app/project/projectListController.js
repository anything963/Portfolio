(function () {

    "use strict";

    angular
        .module("portfolio")
        .controller("projectListController",
                    ["projectResource",
                        ProjectListController]);

    function ProjectListController(projectResource) {
        var vm = this;

        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }


        projectResource.get(function (data) {
            vm.projects = data.results;
            vm.nextPage = getParameterByName("page", data.nextPageUrl);
            vm.previousPage = getParameterByName("page", data.previousPageUrl);
        });

        vm.nextProjects = function ($event) {
            vm.disableBtnNext = true;
            $event.preventDefault();
            $event.stopPropagation();
            if (vm.nextPage != null) {
                projectResource.get({ page: vm.nextPage }, function (data) {
                    vm.projects = data.results;
                    vm.nextPage = getParameterByName("page", data.nextPageUrl);
                    vm.previousPage = getParameterByName("page", data.previousPageUrl);
                    console.log(data);
                    vm.disableBtnNext = false;
                });
            }
            
        };

        vm.previousProjects = function ($event) {
            vm.disableBtnPrevious = true;
            $event.preventDefault();
            $event.stopPropagation();
            if (vm.previousPage != null) {
                projectResource.get({ page: vm.previousPage }, function (data) {
                    vm.projects = data.results;
                    vm.nextPage = getParameterByName("page", data.nextPageUrl);
                    vm.previousPage = getParameterByName("page", data.previousPageUrl);
                    console.log(data);
                    vm.disableBtnPrevious = false;
                });
            }
            
        };
    }

    


})();