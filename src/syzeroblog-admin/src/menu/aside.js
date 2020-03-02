// 菜单 侧边栏
export default [
  { path: '/admin', title: '首页', icon: 'home' },
  {
    title: '分类管理',
    icon: 'folder-o',
    children: [
      { path: '/admin/page2', title: '分类列表' }
    ]
  },
  {
    title: '文章管理',
    icon: 'folder-o',
    children: [
      { path: '/admin/page1', title: '添加文章' },
      { path: '/admin/page2', title: '文章列表' },
      { path: '/admin/page3', title: '回收站' }
    ]
  },
  {
    title: '博客管理',
    icon: 'folder-o',
    children: [
      { path: '/admin/page1', title: '评论列表' },
      { path: '/admin/page1', title: '留言列表' }
    ]
  },
  {
    title: '用户管理',
    icon: 'folder-o',
    children: [
      { path: '/admin/page1', title: '用户列表' }
    ]
  },
  {
    title: '网站管理',
    icon: 'folder-o',
    children: [
      { path: '/admin/page1', title: '页面管理' },
      { path: '/admin/page2', title: '导航管理' },
      { path: '/admin/page2', title: '友情链接' },
      { path: '/admin/page3', title: '站点设置' }
    ]
  }
]
