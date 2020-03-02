<template>
  <d2-container>
    <template slot="header">Page 1 header</template>
    Hello World1111111111165656{{ uploading }}
    <el-card v-for="(item, key) in UserList" :key="key"
      >{{ item.name }} {{ key }}</el-card
    >
    <el-button type="primary" icon="el-icon-edit" circle @click="GetList">sssss</el-button>
  </d2-container>
</template>

<script>
import { User } from '@api/User'
export default {
  data () {
    return {
      uploading: 'sad3sa',
      UserList: []
    }
  },
  created () {
    console.log('ssss')
  },
  methods: {
    GetList() {
      User().then(res => {
        console.log(res)
        this.UserList = res
      })
    }
  }
}
</script>
