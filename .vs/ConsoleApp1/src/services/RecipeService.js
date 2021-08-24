import axios from 'axios';
import store from '../store/index'

const path = '/pantry';

export default {
  
  addIngredient(ingredient) {
    ingredient.userId = store.state.user.userId;
    console.log("Reached add ingredient in service", ingredient)
    return axios.post(path, ingredient)
  },

  addRecipe(recipes) {
    recipes.userId = store.state.user.userId;
    console.log("Reached add ingredient in service", recipes)
    return axios.post(path + "/addrecipe", recipes)
  },

  allIngredients() {
    const userId = store.state.user.userId;
    console.log("Reached all ingredients in service")
    return axios.get(path + "/" + userId)
  },

  getRecipes() {
    const userId = store.state.user.userId;
    console.log("Reached all Recipes in service")
    return axios.get(path + "/getrecipe/" + userId)
  },

  getRecipe(recipeId) {
    return axios.get(path + '/getrecipe/' + recipeId)

  },

  deleteRecipe(recipeId) {
    console.log("Reached Recipe Delete in service", recipeId)

    return axios.delete(path + '/deleterecipe/' + recipeId)
  },

  modifyRecipe(recipe, recipeId) {
    console.log("Reached recipe Modify in service", recipe)
    return axios.put(path + '/modifyrecipe/' + recipeId, recipe )
  }

}
