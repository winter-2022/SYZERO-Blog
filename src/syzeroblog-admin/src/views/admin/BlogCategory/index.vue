<template>
  <d2-container>
    <template slot="header">分类管理</template>
    <d2-crud
      ref="d2Crud"
      :columns="columns"
      :data="data"
      :rowHandle="rowHandle"
      edit-title="我的修改"
      :edit-template="editTemplate"
      :add-template="editTemplate"
      :form-options="formOptions"
      :add-rules="formRules"
      :edit-rules="formRules"
      :options="options"
      @row-edit="handleRowEdit"
      @row-add="handleRowAdd"
      @row-remove="handleRowRemove"
      @dialog-cancel="handleDialogCancel"
    >
      <el-button slot="header" style="margin-bottom: 5px" @click="addRow"
        >添加分类</el-button
      >
    </d2-crud>
  </d2-container>
</template>

<script>
export default {
  data () {
    return {
      columns: [
        {
          title: '排序',
          key: 'order',
          width: '80',
          sortable: true,
          align: 'center'
        },
        {
          title: '名称',
          key: 'name',
          width: '200'
        },
        {
          title: '描述',
          key: 'describe'
        },
        {
          title: '别名',
          key: 'alias',
          width: '180'
        },
        {
          title: '文章',
          key: 'blognum',
          width: '80',
          sortable: true,
          align: 'center'
        }
      ],
      data: [
        {
          describe: '2016-05-02',
          name: '成为',
          alias: 'efe',
          blognum: 5,
          order: 0
        },
        {
          describe: '额wv个啊本人啊别让他人不',
          name: '问过',
          alias: 'wer',
          blognum: 2,
          order: 0
        },
        {
          describe: '2016-05-01',
          name: '王小虎',
          alias: 'we',
          blognum: 4,
          order: 0
        }
      ],
      rowHandle: {
        columnHeader: '编辑表格',
        width: '240',
        edit: {
          icon: 'el-icon-edit',
          text: '编辑',
          size: 'small'
        },
        remove: {
          icon: 'el-icon-delete',
          text: '删除',
          size: 'small'
        }
      },
      editTemplate: {
        name: {
          title: '名称',
          value: ''
        },
        alias: {
          title: '别名',
          value: ''
        },
        parentid: {
          title: '父分类',
          value: '',
          component: {
            name: 'el-select',
            options: [{ label: '无', value: '' }]
          }
        },
        describe: {
          title: '描述',
          value: '',
          component: {}
        },
        order: {
          title: '排序',
          value: '',
          component: {
            name: 'el-input-number'
          }
        }
      },
      formOptions: {
        labelWidth: '80px',
        labelPosition: 'left',
        saveLoading: false
      },
      formRules: {
        name: [{ required: true, message: '请输入名称', trigger: 'blur' }]
      },
      options: {
        border: true
      }
    }
  },
  methods: {
    addRow () {
      this.$refs.d2Crud.showDialog({
        mode: 'add'
      })
    },
    handleRowAdd (row, done) {
      this.formOptions.saveLoading = true
      setTimeout(() => {
        console.log(row)
        this.$message({
          message: '保存成功',
          type: 'success'
        })

        // done可以传入一个对象来修改提交的某个字段
        done({
          blognum: 0
        })
        this.formOptions.saveLoading = false
      }, 300)
    },
    handleRowEdit ({ index, row }, done) {
      this.formOptions.saveLoading = true
      setTimeout(() => {
        console.log(index)
        console.log(row)
        this.$message({
          message: '编辑成功',
          type: 'success'
        })

        // done可以传入一个对象来修改提交的某个字段
        done({
          address: '我是通过done事件传入的数据！'
        })
        this.formOptions.saveLoading = false
      }, 300)
    },
    handleRowRemove ({ index, row }, done) {
      setTimeout(() => {
        console.log(index)
        console.log(row)
        this.$message({
          message: '删除成功',
          type: 'success'
        })
        done()
      }, 300)
    },
    handleDialogCancel (done) {
      this.$message({
        message: '取消保存',
        type: 'warning'
      })
      done()
    }
  }
}
</script>
