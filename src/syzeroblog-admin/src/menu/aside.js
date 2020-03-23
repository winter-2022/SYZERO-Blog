// 菜单 侧边栏
export default [
  {
    title: '新建文章',
    icon: 'clipboard',
    path: '/admin/BlogEdit/new'
  },
  {
    title: '文章管理',
    icon: 'file-text',
    path: '/admin/Blog'
  },
  {
    title: '分类管理',
    icon: 'list-alt',
    path: '/admin/BlogCategory'
  },
  {
    title: '标签管理',
    icon: 'tags',
    path: '/admin/Tag'
  },
  {
    title: '评论管理',
    icon: 'comments',
    path: '/admin/page1'
  },
  {
    title: '留言管理',
    icon: 'commenting',
    path: '/admin/page1'
  },
  {
    title: '用户管理',
    icon: 'user',
    path: '/admin/page1'
  },
  {
    title: '页面管理',
    icon: 'file-o',
    path: '/admin/page1'
  },
  {
    title: '系统管理',
    icon: 'gears',
    children: [
      {
        title: '站点设置',
        icon: 'gear',
        path: '/admin/page3'
      },
      {
        title: '友链管理',
        icon: 'external-link',
        path: '/admin/page1'
      },
      {
        title: '导航管理',
        icon: 'navicon',
        path: '/admin/page1'
      }
    ]
  }
]
