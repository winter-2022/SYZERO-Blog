import request from '@/plugin/axios'

export function AccountLogin (data) {
  return request({
    url: '/TokenAuth/Authenticate',
    method: 'post',
    data
  })
}

export function LogOut () {
  return request({
    url: '/TokenAuth/LogOut',
    method: 'post'
  })
}
