
var app = angular.module("itemsModule", ["ngRoute"]);

app.service("itemsService", function ($http) {

    //get All Items
    this.getItems = function () {
        return $http.get("/Home/GetItems");
    };

    this.getPager = function (totalItems, currentPage, pageSize) {
        debugger;
        currentPage = currentPage || 1;

        pageSize = pageSize || 5;

        var totalPages = Math.ceil(totalItems / pageSize);

        var startPage, endPage;

        if (totalPages <= 10) {
            startPage = 1;
            endPage = totalPages;
        } else {
           //  more than 10 total pages so calculate start and end pages
            if (currentPage <= 6) {
                startPage = 1;
                endPage = 10;
            } else if (currentPage + 4 >= totalPages) {
                startPage = totalPages - 9;
                endPage = totalPages;
            } else {
                startPage = currentPage - 5;
                endPage = currentPage + 4;
            }
        }

        var startIndex = (currentPage - 1) * pageSize;
        var endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);

        var pages = _.range(startPage, endPage + 1);

        return {
            totalItems: totalItems,
            currentPage: currentPage,
            pageSize: pageSize,
            totalPages: totalPages,
            startPage: startPage,
            endPage: endPage,
            startIndex: startIndex,
            endIndex: endIndex,
            pages: pages
        }
    }
});


app.controller("itemsController", function ($scope, itemsService) {
    var vm = this;
    vm.dummyItems = {};
    vm.pager = {};
    vm.setPage = setPage;

    vm.showItemsPerPage = [5, 10, 50, 100];
   
    initController();

    function GetAllItems() {
        debugger;
        var getData = itemsService.getItems();

        getData.then(function (itm) {
            $scope.items = itm.data;
            vm.dummyItems = itm.data;
        }, function (itm) {

        });
    }

    function initController() {
        // initialize to page 1
        $scope.itemsPerPage = 5;
        vm.setPage(1);
    }

    function setPage(page, pageSize) {
        if (page < 1 || page > vm.pager.totalPages) {
            return;
        }
        vm.pageSize = pageSize;

        var getData = itemsService.getItems();
        getData.then(function (data)
        {
            debugger;
            
            vm.dummyItems =angular.fromJson(data).data;

            vm.pager = itemsService.getPager(vm.dummyItems.length, page, vm.pageSize);

            
            //// get current page of items
            vm.items = vm.dummyItems.slice(vm.pager.startIndex, vm.pager.endIndex + 1);
        });
    }
})

