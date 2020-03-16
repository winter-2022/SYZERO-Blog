import request from '@/plugin/axios'

/**
 * 获取所有博客分类
 */
export function GetBlogCategory() {
  return request({
    url: '/Service/BlogCategory/All',
    method: 'get'
  })
}

/**
 * 添加博客分类
 */
export function AddBlogCategory(data) {
  return request({
    url: '/Service/BlogCategory',
    method: 'post',
    data
  })
}

/**
 * 修改博客分类
 */
export function UpdataBlogCategory(data) {
  return request({
    url: '/Service/BlogCategory',
    method: 'put',
    data
  })
}

/**
 * 删除博客分类
 */
export function DelBlogCategory(Id) {
  return request({
    url: '/Service/BlogCategory?Id=' + Id,
    method: 'delete'
  })
}
