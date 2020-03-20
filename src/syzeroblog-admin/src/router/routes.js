import layoutHeaderAside from '@/layout/header-aside'

// 由于懒加载页面太多的话会造成webpack热更新太慢，所以开发环境不使用懒加载，只有生产环境使用懒加载
const _import = require('@/libs/util.import.' + process.env.NODE_ENV)

/**
 * 在主框架内显示
 */
const frameIn = [{
  path: '/admin',
  redirect: {
    name: 'admin'
  },
  component: layoutHeaderAside,
  children: [
    // 首页
    {
      path: '/admin',
      name: 'admin',
      meta: {
        title: '首页',
        auth: true
      },
      component: _import('system/admin')
    },
    {
      path: 'BlogCategory',
      name: 'BlogCategory',
      meta: {
        title: '博客分类',
        auth: true
      },
      component: _import('admin/BlogCategory')
    },
    {
      path: 'Tag',
      name: 'Tag',
      meta: {
        title: '标签列表',
        auth: true
      },
      component: _import('admin/Tag')
    },
    {
      path: 'Blog',
      name: 'Blog',
      meta: {
        title: '文章',
        auth: true
      },
      component: _import('admin/Blog')
    },
    {
      path: 'BlogEdit/:id',
      name: 'BlogEdit',
      meta: {
        title: '编辑文章',
        auth: true,
        cache: true
      },
      props: true,
      component: _import('admin/Blog/Edit')
    },
    // 演示页面
    {
      path: 'page1',
      name: 'page1',
      meta: {
        title: '页面 1',
        auth: true
      },
      component: _import('admin/page1')
    },
    {
      path: 'page2',
      name: 'page2',
      meta: {
        title: '页面 2',
        auth: true
      },
      component: _import('admin/page2')
    },
    {
      path: 'page3',
      name: 'page3',
      meta: {
        title: '页面 3',
        auth: true
      },
      component: _import('admin/page3')
    },
    // 系统 前端日志
    {
      path: 'log',
      name: 'log',
      meta: {
        title: '前端日志',
        auth: true
      },
      component: _import('system/log')
    },
    // 刷新页面 必须保留
    {
      path: 'refresh',
      name: 'refresh',
      hidden: true,
      component: _import('system/function/refresh')
    },
    // 页面重定向 必须保留
    {
      path: 'redirect/:route*',
      name: 'redirect',
      hidden: true,
      component: _import('system/function/redirect')
    }
  ]
}]

/**
 * 在主框架之外显示
 */
const frameOut = [
  // 登录
  {
    path: '/login',
    name: 'login',
    component: _import('system/login')
  },
  {
    path: '/',
    name: 'redirectAdmin',
    redirect: {
      name: 'admin'
    }
  }
]

/**
 * 错误页面
 */
const errorPage = [{
  path: '*',
  name: '404',
  component: _import('system/error/404')
}]

// 导出需要显示菜单的
export const frameInRoutes = frameIn

// 重新组织后导出
export default [
  ...frameIn,
  ...frameOut,
  ...errorPage
]
