import request from '@/plugin/axios'

/**
 * 获取所有标签
 */
export function GetTag(params) {
  return request({
    url: '/Service/Tag/All',
    method: 'get',
    params
  })
}

/**
 * 添加标签
 */
export function AddTag(data) {
  return request({
    url: '/Service/Tag',
    method: 'post',
    data
  })
}

/**
 * 修改标签
 */
export function UpdataTag(data) {
  return request({
    url: '/Service/Tag',
    method: 'put',
    data
  })
}

/**
 * 删除标签
 */
export function DelTag(Id) {
  return request({
    url: '/Service/Tag?Id=' + Id,
    method: 'delete'
  })
}
