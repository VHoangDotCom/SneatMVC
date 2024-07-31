
'use strict';

$(function () {
    var theme = $('html').hasClass('light-style') ? 'default' : 'default-dark',
        checkboxTree = $('#tree-role');

    // List Tree fo creating
    if (checkboxTree.length) {
        $.ajax({
            url: '/Roles/GetAllPermissions', 
            method: 'GET',
            success: function (data) {
                console.log(data)
                var jsTreeData = transformToJsTreeFormat(data);
                initializeJsTree(jsTreeData);
            },
            error: function (error) {
                console.error('Error fetching permissions:', error);
            }
        });
    }

    function transformToJsTreeFormat(data) {
        function transformNode(node) {
            return {
                id: node.Item.ID,       
                text: node.Item.Name,    
                children: node.Children ? node.Children.map(transformNode) : [], 
                state: {
                    opened: true,
                    //selected: preSelectedIds.includes(node.Item.ID)
                    selected: false
                },
                type: node.Item.TabIcon,//not work
            };
        }

        return {
            id: data.Id,
            text: data.Name,
            children: data.Childrens ? data.Childrens.map(transformNode) : [],
            state: {
                opened: true 
            }
        };
    }

    function initializeJsTree(data) {
        checkboxTree.jstree({
            core: {
                themes: {
                    name: theme
                },
                data: [data]
            },
            plugins: ['types', 'checkbox', 'wholerow'],
            types: {
                default: {
                    icon: 'bx bxl-stripe text-primary'
                },
              /*  html: {
                    icon: 'bx bxl-html5 text-danger'
                },
                css: {
                    icon: 'bx bxl-css3 text-info'
                },
                img: {
                    icon: 'bx bx-image text-success'
                },
                js: {
                    icon: 'bx bxl-nodejs text-warning'
                },*/
                user: {
                    icon: 'bx bx-user text-secondary'
                },
                home: {
                    icon: 'bx bx-home-circle text-info'
                }
            }
        });
    }

    window.treeData = function () {
        // Get selected nodes
        var selectedNodes = checkboxTree.jstree("get_selected", true);
        var selectedItems = selectedNodes.map(function (node) {
            return {
                id: node.id,
                text: node.text
            };
        });

        console.log('Selected Items:', selectedItems);
    }
});


$(function () {
    /*var theme = $('html').hasClass('light-style') ? 'default' : 'default-dark',
        checkboxTreeUpdate = $('#update-tree-role');

    // List tree for updating
    if (checkboxTreeUpdate.length) {
        $.ajax({
            url: '/Roles/GetAllPermissions',
            method: 'GET',
            success: function (data) {
                //var preSelectedIds = $("#listPermissonIds").val();
                //console.log(preSelectedIds);
                var jsTreeData = transformToJsTreeFormatUpdate(data);
                initializeJsTree(jsTreeData);
            },
            error: function (error) {
                console.error('Error fetching permissions:', error);
            }
        });
    }

    function transformToJsTreeFormatUpdate(data) {
        var listIds = $("#listPermissonIds").val();// 1,2,3,4,5
        var preSelectedIds = listIds.split(',').map(Number);// [1, 2, 3, 4, 5]
        function transformNode(node) {
            return {
                id: node.Item.ID,
                text: node.Item.Name,
                children: node.Children ? node.Children.map(transformNode) : [],
                state: {
                    opened: true,
                     selected: preSelectedIds.includes(node.Item.ID)
                },
                type: node.Item.TabIcon,//not work
            };
        }

        return {
            id: data.Id,
            text: data.Name,
            children: data.Childrens ? data.Childrens.map(transformNode) : [],
            state: {
                opened: true
            }
        };
    }

    function initializeJsTree(data) {
        checkboxTreeUpdate.jstree({
            core: {
                themes: {
                    name: theme
                },
                data: [data]
            },
            plugins: ['types', 'checkbox', 'wholerow'],
            types: {
                default: {
                    icon: 'bx bxl-stripe text-primary'
                },
                user: {
                    icon: 'bx bx-user text-secondary'
                },
                home: {
                    icon: 'bx bx-home-circle text-info'
                }
            }
        });
    }*/

});