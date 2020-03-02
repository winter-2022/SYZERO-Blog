import request from '@/plugin/axios'

export function User () {
  return request({
    url: '/Service/User/User',
    method: 'post'
  })
}
