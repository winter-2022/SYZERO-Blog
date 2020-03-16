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
      @dialog-cancel="handleDialogCancel"
      @custom-edit="editRow"
      @custom-delete="handleRowRemove"
    >
      <el-button slot="header" style="margin-bottom: 5px" @click="addRow">添加分类</el-button>
    </d2-crud>
  </d2-container>
</template>

<script>
import {
  GetBlogCategory,
  AddBlogCategory,
  UpdataBlogCategory,
  DelBlogCategory
} from "../../../api/BlogCategory";
export default {
  data() {
    return {
      columns: [
        {
          title: "排序",
          key: "order",
          width: "80",
          sortable: true,
          align: "center"
        },
        {
          title: "名称",
          key: "name",
          width: "200"
        },
        {
          title: "描述",
          key: "describe"
        },
        {
          title: "别名",
          key: "alias",
          width: "180"
        },
        {
          title: "文章",
          key: "blognum",
          width: "80",
          sortable: true,
          align: "center"
        }
      ],
      data: [
        {
          describe: "2016-05-02",
          name: "成为",
          alias: "efe",
          blognum: 5,
          order: 0
        },
        {
          describe: "额wv个啊本人啊别让他人不",
          name: "问过",
          alias: "wer",
          blognum: 2,
          order: 0
        },
        {
          describe: "2016-05-01",
          name: "王小虎",
          alias: "we",
          blognum: 4,
          order: 0
        }
      ],
      rowHandle: {
        columnHeader: "操作",
        width: "240",
        custom: [
          {
            icon: "el-icon-edit",
            emit: "custom-edit",
            text: "编辑",
            size: "small",
            type: "primary"
          },
          {
            icon: "el-icon-delete",
            emit: "custom-delete",
            text: "删除",
            size: "small",
            type: "danger"
          }
        ]
      },
      editTemplate: {
        name: {
          title: "名称",
          value: ""
        },
        alias: {
          title: "别名",
          value: ""
        },
        parentId: {
          title: "父分类",
          value: "",
          component: {
            name: "el-select",
            options: [{ label: "无", value: "" }]
          }
        },
        describe: {
          title: "描述",
          value: "",
          component: {}
        },
        order: {
          title: "排序",
          value: "",
          component: {
            name: "el-input-number"
          }
        }
      },
      formOptions: {
        labelWidth: "80px",
        labelPosition: "left",
        saveLoading: false
      },
      formRules: {
        name: [{ required: true, message: "请输入名称", trigger: "blur" }]
      },
      options: {
        border: true
      }
    };
  },
  mounted() {
    GetBlogCategory().then(res => {
      this.data = res.list;
    });
  },
  methods: {
    addRow() {
      GetBlogCategory().then(res => {
        let options = [{ label: "最上级", value: null }];
        options = options.concat(
          res.list
            .filter(p => {
              return p.parentId == null;
            })
            .map(p => {
              return { label: p.name, value: p.id };
            })
        );
        this.editTemplate.parentId.component.options = options;
        this.$refs.d2Crud.showDialog({
          mode: "add"
        });
      });
    },
    editRow({ index, row }) {
      GetBlogCategory().then(res => {
        let options = [{ label: "最上级", value: null }];
        options = options.concat(
          res.list
            .filter(p => {
              return p.parentId == null;
            })
            .map(p => {
              return { label: p.name, value: p.id };
            })
        );
        this.editTemplate.parentId.component.options = options;
        this.$refs.d2Crud.showDialog({
          mode: "edit",
          rowIndex: index
        });
      });
    },
    handleRowRemove({ index, row }) {
      this.$refs.d2Crud.removeRow({
        index: index
      });
      this.$confirm("确定删除吗？", "删除", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          DelBlogCategory(row.id).then(res => {
            this.$message({
              message: "删除成功",
              type: "success"
            });
            this.data.splice(index, 1);
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除"
          });
        });
    },
    handleRowAdd(row, done) {
      this.formOptions.saveLoading = true;
      AddBlogCategory(row).then(res => {
        console.log(res);
        this.$message({
          message: "保存成功",
          type: "success"
        });
        done({
          blognum: 0
        });
        this.formOptions.saveLoading = false;
      });
    },
    handleRowEdit({ index, row }, done) {
      this.formOptions.saveLoading = true;
      UpdataBlogCategory(row).then(res => {
        console.log(res);
        this.$message({
          message: "编辑成功",
          type: "success"
        });
        done({
          blognum: 0
        });
        this.formOptions.saveLoading = false;
      }, 300);
    },
    handleDialogCancel(done) {
      this.$message({
        message: "取消保存",
        type: "warning"
      });
      done();
    }
  }
};
</script>
