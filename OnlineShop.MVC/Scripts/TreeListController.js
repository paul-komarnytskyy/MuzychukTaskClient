var appBo = angular.module('appBo', ['itemsModule']);

//appBo.directive('tree', function () {
//    return {
//        restrict: 'E', // tells Angular to apply this to only html tag that is <tree>
//        replace: true, // tells Angular to replace <tree> by the whole template
//        scope: {
//            t: '=src' // create an isolated scope variable 't' and pass 'src' to it.  
//        },
//        template: '<ul><branch ng-repeat="c in t.children" src="c" ng-click="ShowChildren"></branch></ul>'
//        //template: '<ul><branch ng-repeat="c in t.children" src="c" ng-click="showChilds($index)"></branch></ul>'
//    };
//})

//appBo.directive('branch', function ($compile) {
//    return {
//        restrict: 'E', // tells Angular to apply this to only html tag that is <branch>
//        replace: true, // tells Angular to replace <branch> by the whole template
//        scope: {
//            b: '=src', // create an isolated scope variable 'b' and pass 'src' to it.  
//        },
//        template: '<li><a>{{ b.name }}</a></li>',
//        link: function (scope, element, attrs) {
//            //// Check if there are any children, otherwise we'll have infinite execution

//            var has_children = angular.isArray(scope.b.children);

//            //// Manipulate HTML in DOM
//            if (has_children) {
//                element.append('<tree src="b"></tree>');

//                // recompile Angular because of manual appending
//                $compile(element.contents())(scope);

//                element.toggleClass('collapsed');

//            } else {
//                element.append(scope + btnhtml);
//            }
            
//            var scope1 = scope;
//            var attrs1 = attrs;

//            //// Bind events
//            element.on('click', function (event) {
//                event.stopPropagation();

//                if (has_children) {
//                    element.toggleClass('collapsed');
//                }
//            });
//        }
//    };
//})

appBo.controller('TreeListController', function ($scope) {
    $scope.title = "Tree";

    $scope.data = [
      { id: '1', label: 'root', parentId: 'null', $expand: true },
      { id: '2', label: 'child 11', parentId: '1', $expand: false },
      { id: '3', label: 'child 12', parentId: '1', $expand: false },
      { id: '4', label: 'child 13', parentId: '1', $expand: false },
      { id: '5', label: 'child 14', parentId: '1', $expand: false },
      { id: '6', label: 'child 111', parentId: '2', $expand: false },
      { id: '7', label: 'child 1111', parentId: '6', $expand: false },
      { id: '8', label: 'child 121', parentId: '3', $expand: false },
      { id: '9', label: 'child 122', parentId: '3', $expand: false },
      { id: '9', label: 'child 131', parentId: '4', $expand: false }
    ];

    $scope.getChildren = function (parentId) {
        if (!parentId) {
            return [$scope.data[0]];
        }

        if (!_($scope.data).filter({ id: parentId }).value()[0]['$expand']) {
            return [];
        }
        return _($scope.data).filter({ parentId: parentId }).value();
    }

    $scope.hasChildren = function (id) {
        if (!id) {
            return (_($scope.data).filter({ parentId: $scope.data[0].id }).value().length !== 0);
        }

        return (_($scope.data).filter({ parentId: id }).value().length !== 0);
    }
    $scope.test = function()
    {
        debugger;
    }
});

//appBo.controller('TreeListController', function ($scope) {
    //$scope.categories = {
    //    children: [
    //      {
    //          name: "Women",
    //          children: [
    //            {
    //                name: "Top",
    //                children: [
    //                  {
    //                      name: "Blouse"
    //                  },
    //                  {
    //                      name: "Tank"
    //                  }
    //                ]
    //            },
    //            {
    //                name: "Bottom",
    //                children: [
    //                  {
    //                      name: "Skirt"
    //                  },
    //                  {
    //                      name: "Dress"
    //                  }
    //                ]
    //            }
    //          ]
    //      },
    //      {
    //          name: "Men",
    //          children: [
    //            {
    //                name: "Top",
    //                children: [
    //                  {
    //                      name: "Shirt"
    //                  },
    //                  {
    //                      name: "T-shirt"
    //                  }
    //                ]
    //            },
    //            {
    //                name: "Bottom",
    //                children: [
    //                  {
    //                      name: "Pants"
    //                  },
    //                  {
    //                      name: "Shorts"
    //                  }
    //                ]
    //            }
    //          ]
    //      }
    //    ]
    //};
//});