import request from '@/plugin/axios'

/**
 * 获取所有用户
 */
export function GetUser (params) {
  return request({
    url: '/Service/User/All',
    method: 'get',
    params
  })
}

/**
 * 添加用户
 */
export function AddUser (data) {
  return request({
    url: '/Service/User',
    method: 'post',
    data
  })
}

/**
 * 修改用户
 */
export function UpdataUser (data) {
  return request({
    url: '/Service/User',
    method: 'put',
    data
  })
}

/**
 * 删除用户
 */
export function DelUser (Id) {
  return request({
    url: '/Service/User?Id=' + Id,
    method: 'delete'
  })
}
