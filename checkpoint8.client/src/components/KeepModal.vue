<template>
  <!-- SECTION this is the modal that pops up when the recipe card is clicked. -->
  <div class="row">
    <div class="col-12">
      <div
        class="modal fade"
        id="keepModal"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-xl">
          <div class="modal-content">
            <div class="container-fluid">
              <div class="row">
                <div class="col-12 col-md-5 p-0 m-0">
                  <img class="img-fluid" :src="keep.img" alt="" />
                </div>
                <div class="col-10 col-md-7">
                  <div class="pt-3 justify-content-start d-flex">
                    <p class="title-font pb-2 m-0 p-0">
                      <b>{{ keep.name }}</b>
                    </p>
                  </div>
                  <div class="justify-content-start d-flex">
                    <p class="desc-font">{{ keep.description }}</p>
                  </div>
                  <div class="justify-content-evenly d-flex m-2 mt-2 mb-3 pb-2">
                    <div class="col-10 col-md-6 order-2 order-md-1 shadow mx-2">
                      <div class="steps text-white p-2 rounded-top">
                        <h4>Recipe Steps</h4>
                      </div>
                      <div class="text-start p-3 border rounded-bottom">
                        <div class="scrolling">
                          <p>
                            1. In a Dutch oven, cook bacon over medium heat
                            until crisp. Remove to paper towels with a slotted
                            spoon; drain, reserving 1 tablespoon drippings.
                            Saute onion in drippings until tender. Add garlic;
                            cook 1 minute longer.
                          </p>

                          <p>
                            2. Stir in the broth, pumpkin, salt, nutmeg and
                            pepper. Bring to a boil. Reduce heat; simmer,
                            uncovered, for 10 minutes. Cool slightly.
                          </p>
                          <p>
                            3. In a blender, process soup in batches until
                            smooth. Return all to pan. Stir in cream; heat
                            through. Add cheese; stir until melted. Sprinkle
                            each serving with parsley, bacon and, if desired,
                            additional cheese.
                          </p>
                        </div>
                        <form>
                          <label for="description"></label>
                          <input
                            type="text"
                            name="description"
                            id="description"
                            class="w-100"
                            placeholder="Enter new step"
                          />
                        </form>
                      </div>
                    </div>
                    <div class="col-10 col-md-6 order-1 order-md-2 shadow mx-2">
                      <div class="steps text-white p-2 rounded-top">
                        <h4>Ingredients</h4>
                      </div>
                      <div class="text-start p-3 border rounded-bottom">
                        <div class="scrolling">
                          <p>
                            4 bacon strips<br />
                            chopped 1 medium onion<br />
                            chopped 3 garlic cloves<br />
                            minced 6 cups chicken broth 1 can (29 ounces)<br />
                            solid-pack pumpkin <br />
                            1/2 teaspoon salt <br />
                            1/4 teaspoon ground nutmeg <br />
                            1/8 teaspoon pepper <br />
                            1 cup heavy whipping cream <br />
                            1 cup shredded Gouda cheese <br />
                            2 tablespoons minced fresh parsley <br />
                            Additional shredded Gouda cheese, optional
                          </p>
                        </div>
                        <form class="align-items-end d-flex">
                          <label for="description"></label>
                          <input
                            type="text"
                            name="description"
                            id="description"
                            class="w-100"
                            placeholder="Enter new step"
                          />
                        </form>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- SECTION this end's the section for the modal that pops up when the recipe card is clicked. -->
</template>

<script>
import { AppState } from '../AppState';
export default {
  setup() {
    return {
      keep: computed(() => AppState.activeKeep)
    };
  },
};
</script>

<style scoped>
</style>
