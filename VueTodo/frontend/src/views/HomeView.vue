<script>
import axios from "axios";
export default {
  name: "HomeView",
  data: () => ({
    title: "Home",
    todos: [],
    todoText: "",
  }),
  methods: {
    addTodo() {
      axios
        .post("http://localhost:5100/todos", {
          name: this.todoText,
          isComplete: false,
        })
        .then((response) => {
          console.log(response);
        });
      // this.todos.push({
      //   name: this.todoText,
      //   isComplete: false,
      // });
      // this.todoText = "";
    },
    removeTodo(index) {
      this.todos.splice(index, 1);
    },
  },
  mounted: function () {
    axios.get("http://localhost:5100/todos").then((response) => {
      this.todos = response.data;
    });
  },
};
</script>

<template>
  <div class="todos-main">
    <div class="todos-header">
      <h1 class="todos-title">{{ title }}</h1>
    </div>
    <div class="todos-body">
      <div class="todos-list-title">
        <h2 class="todos-list-title-text">My Todos</h2>
      </div>
      <div class="todos-list">
        <div class="todos-item" v-for="(todo, index) in todos" :key="index">
          <div class="todos-item-text">
            <input
              type="checkbox"
              class="todos-item-checkbox"
              v-model="todo.isComplete"
            />
            <span :class="{ done: todo.isComplete }">{{ todo.name }}</span>
          </div>
          <button class="todos-item-remove" @click="removeTodo(index)">
            Delete
          </button>
        </div>
      </div>
      <div class="todos-add">
        <input
          type="text"
          class="todos-add-input"
          placeholder="Add todo"
          v-model="todoText"
        />
        <button class="todos-add-button" @click="addTodo">Add new todo</button>
      </div>
    </div>
  </div>
</template>
