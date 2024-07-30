/**
 * Treeview (jquery)
 */

'use strict';

$(function () {
    var theme = $('html').hasClass('light-style') ? 'default' : 'default-dark',
        checkboxTree = $('#tree-role');

    
    // Checkbox
    // --------------------------------------------------------------------
    if (checkboxTree.length) {
        checkboxTree.jstree({
            core: {
                themes: {
                    name: theme
                },
                data: [
                    {
                        id: 1,
                        text: 'css',
                        children: [
                            {
                                id: 5,
                                text: 'app.css',
                                type: 'css'
                            },
                            {
                                id: 6,
                                text: 'style.css',
                                type: 'css'
                            }
                        ]
                    },
                    {
                        id: 2,
                        text: 'img',
                        state: {
                            opened: false
                        },
                        children: [
                            {
                                text: 'bg.jpg',
                                type: 'img'
                            },
                            {
                                text: 'logo.png',
                                type: 'img'
                            },
                            {
                                text: 'avatar.png',
                                type: 'img'
                            }
                        ]
                    },
                    {
                        id: 3,
                        text: 'js',
                        state: {
                            opened: false
                        },
                        children: [
                            {
                                text: 'jquery.js',
                                type: 'js',
                                children: [
                                    {
                                        text: 'jquery.js',
                                        type: 'js',
                                        children: [
                                            {
                                                text: 'jquery.js',
                                                type: 'js'
                                            },
                                            {
                                                text: 'app.js',
                                                type: 'js'
                                            }
                                        ]
                                    },
                                    {
                                        text: 'app.js',
                                        type: 'js'
                                    }
                                ]
                            },
                            {
                                text: 'app.js',
                                type: 'js'
                            }
                        ]
                    },
                   
                    {
                        id: 4,
                        text: 'page-one.html',
                        type: 'html'
                    }
                ]
            },
            plugins: ['types', 'checkbox', 'wholerow'],
            types: {
                default: {
                    icon: 'bx bx-folder'
                },
                html: {
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
                }
            }
        });
    }

});
