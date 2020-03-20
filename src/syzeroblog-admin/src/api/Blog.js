import request from '@/plugin/axios'
/**
 * 获取所有博客分类
 */
export function GetBlog (params) {
  return request({
    url: '/Service/Blog/All',
    method: 'get',
    params
  })
}

/**
 * 添加博客
 */
export function AddBlog(data) {
  return request({
    url: '/Service/Blog',
    method: 'post',
    data
  })
}

/**
 * 删除博客分类
 */
export function DelBlog (Id) {
  return request({
    url: '/Service/Blog?Id=' + Id,
    method: 'delete'
  })
}
