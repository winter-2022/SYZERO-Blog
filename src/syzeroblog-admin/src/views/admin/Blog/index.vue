<template>
  <d2-container>
    <template slot="header">分类管理</template>
    <el-header>
      <el-button @click="addRow">新增</el-button>
    </el-header>
    <!-- Table -->
    <el-table :data="data"
              border
              style="width: 100%"
              @selection-change="handleSelectionChange">
      <el-table-column type="selection"
                       width="55">
      </el-table-column>
      <el-table-column prop="title"
                       label="标题"
                       width="180">
      </el-table-column>
      <el-table-column prop="alias"
                       label="别名"
                       width="180">
      </el-table-column>
      <el-table-column prop="categoryName"
                       label="分类">
      </el-table-column>
      <el-table-column prop="alias"
                       label="作者">
      </el-table-column>
      <el-table-column prop="createTime"
                       label="时间">
      </el-table-column>
      <el-table-column prop="commentNums"
                       label="评论数">
      </el-table-column>
      <el-table-column prop="viewNums"
                       label="查看次数">
      </el-table-column>
      <el-table-column label="操作"
                       width="145"
                       align="center">
        <template slot-scope="scope">
          <el-button size="mini"
                     @click="editRow(scope.$index, scope.row)">编辑</el-button>
          <el-button size="mini"
                     type="danger"
                     @click="handleRowRemove(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-pagination @size-change="handleSizeChange"
                   @current-change="handleCurrentChange"
                   :current-page="currentPage"
                   :page-sizes="[10,20, 40, 80, 100]"
                   :page-size="pageSize"
                   layout="total, sizes, prev, pager, next, jumper"
                   :total="total">
    </el-pagination>
  </d2-container>
</template>

<script>
import {
  GetBlog, DelBlog
} from '../../../api/Blog'

export default {
  data () {
    return {
      data: [],
      total: 100,
      multipleSelection: [],
      index: 0,
      currentPage: 1,
      pageSize: 10

    }
  },
  mounted () {
    this.loadData()
  },
  methods: {
    // 加载数据
    loadData () {
      GetBlog({ Sort: 'title', Skip: ((this.currentPage - 1) * this.pageSize), Limit: this.pageSize }).then(res => {
        this.data = res.list
        this.total = Number(res.total)
      })
    },
    handleSelectionChange (val) {
      this.multipleSelection = val
      this.$message.info(JSON.stringify(val))
    },
    // 显示添加
    addRow () {
      this.formTitle = '添加'
      this.dialogFormVisible = true
      this.form = {
        name: '',
        order: '',
        describe: '',
        alias: '',
        parentId: null
      }
    },
    // 显示编辑
    editRow (index, row) {
      this.$router.push({ path: 'BlogEdit/' + Math.random().toString() })
    },
    // 删除
    handleRowRemove (index, row) {
      this.$confirm('确定删除吗？', '删除', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          DelBlog(row.id).then(res => {
            if (res) {
              this.$message({
                message: '删除成功',
                type: 'success'
              })
              this.loadData()
            } else {
              this.$message({
                message: '删除失败',
                type: 'warning'
              })
            }
          })
        })
        .catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          })
        })
    },
    // 添加
    handleRowAdd () {

    },
    handleSizeChange (val) {
      console.log(`每页 ${val} 条`)
      this.pageSize = val
      this.loadData()
    },
    handleCurrentChange (val) {
      console.log(`当前页: ${val}`)
      this.currentPage = val
      this.loadData()
    }
  }
}

</script>
<style scoped>
.el-header {
  padding: 0;
}
</style>
