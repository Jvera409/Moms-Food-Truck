<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      ><button class="btn">Insert an Ingredient</button></a
    >
    <form v-on:submit.prevent="addNewIngredient" v-if="isFormShown">
      <div class="form-group">
        <label for="IngredientName">Name of Ingredient: </label>
        <input
          required
          type="text"
          id="ingredientName"
          name="ingredientName"
          class="form-control"
          v-model="newItem.ingredientName"
        />
      </div>

      <button class="btn btn-submit">Submit</button>

      <button
        type="cancel"
        v-on:click.prevent="resetForm"
        class="btn btn-cancel"
      >
        Cancel
      </button>
    </form>
  </div>
</template>

<script>
import recipeService from "@/services/RecipeService.js";

export default {
  name: "AddIngredient",
  data() {
    return {
      newItem: {
        ingredientName: "",
      },

      isFormShown: false,
    };
  },

  methods: {
    addNewIngredient() {
      console.log("Reached add ingredient", this.newItem);
      this.$store.commit("ADD_INGREDIENT", this.newItem);

      recipeService.addIngredient(this.newItem).then((response) => {
        console.log("Success", response);
        //this.$router.push({ ingredientName: "Pantry" });
      });
      this.resetForm();
    },

    resetForm() {
      this.newItem = {};
      this.isFormShown = false;
    },
  },
};
</script>

<style scoped>
</style>