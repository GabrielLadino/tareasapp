<template>
    <v-container>
        <v-row>
            <v-col>
                <!-- Formulario -->
                <v-form @submit.prevent="crearTarea">
                    <v-text-field v-model="nuevaTarea.titulo" label="Título" required></v-text-field>
                    <v-textarea v-model="nuevaTarea.descripcion" label="Descripción" required></v-textarea>
                    <v-btn type="submit" color="primary">Agregar Tarea</v-btn>
                </v-form>

            </v-col>
            <!-- Cards -->
            <v-col cols="6">
                <v-row>
                    <v-col v-for="(tarea, index) in tareas" :key="tarea.id" cols="12">
                        <v-card class="pa-1" elevated color="primary" elevation="10">
                            <v-card-title> <v-icon>mdi-clock</v-icon> {{ tarea.titulo }}</v-card-title>
                            <v-card-text>{{ tarea.descripcion }} {{ tarea.fechaCreacion }}</v-card-text>
                            <v-card-actions class="d-flex justify-end">
                                <v-btn icon @click="editarTarea(tarea)">
                                    <v-icon>mdi-pencil</v-icon>
                                </v-btn>
                                <v-btn icon @click="eliminarTarea(tarea.id)">
                                    <v-icon>mdi-delete</v-icon>
                                </v-btn>
                                <v-btn :color="tarea.completado ? 'success' : ''" @click="toggleTaskStatus(tarea)">
                                    {{ tarea.completado ? 'Completado' : 'Pendiente' }}
                                </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
        <!-- Dialogo-->
        <v-dialog v-model="editDialog" persistent max-width="600px">
            <v-card>
                <v-card-title class="headline">Editar Tarea</v-card-title>
                <v-card-text>
                    <v-form @submit.prevent="actualizarTarea">
                        <v-text-field v-model="editarTareaData.titulo" label="Título" required></v-text-field>
                        <v-textarea v-model="editarTareaData.descripcion" label="Descripción" required></v-textarea>
                        <v-checkbox v-model="editarTareaData.completado"
                            :label="editarTareaData.completado ? 'Completado' : 'Pendiente'"></v-checkbox>
                        <v-btn type="submit" color="primary" class="mr-2">Actualizar Tarea</v-btn>
                        <v-btn color="grey" @click="editDialog = false">Cancelar</v-btn>
                    </v-form>
                </v-card-text>
            </v-card>
        </v-dialog>
    </v-container>
</template>

<script>

import { addTarea, updateTarea, todo,deleteTarea } from '../api/tarea'
export default {
    data() {
        return {
            nuevaTarea: {
                id: 0,
                titulo: '',
                descripcion: '',
                fechaCreacion: '',
                completado: false
            },
            tareas: [],
            editDialog: false,
            editarTareaData: {
                id: null,
                titulo: '',
                descripcion: '',
                fechaCreacion: '',
                completado: false
            }

        };
    },
    methods: {
        async crearTarea() {
            if (this.nuevaTarea.titulo.trim() !== '' && this.nuevaTarea.descripcion.trim() !== '') {
                this.nuevaTarea.fechaCreacion = new Date().toLocaleString();

                let response = await addTarea(this.nuevaTarea)
                this.nuevaTarea.id = response.data.data

                this.tareas.push({ ...this.nuevaTarea });
                this.resetNewTask();
            }
        },
        resetNewTask() {
            this.nuevaTarea = {
                id: 0,
                titulo: '',
                descripcion: '',
                fechaCreacion: '',
                completado: false
            };
        },
        toggleTaskStatus(tarea) {
            tarea.completado = !tarea.completado;
        },
        async eliminarTarea(id) {
            let response= await deleteTarea(id)
            console.log(response);
            this.tareas = this.tareas.filter(tarea => tarea.id !== id);
        },
        editarTarea(tarea) {
            this.editarTareaData = { ...tarea };
            this.editDialog = true;
        },
        actualizarTarea() {
            const tareaIndice = this.tareas.findIndex(tarea => tarea.id === this.editarTareaData.id);
            if (tareaIndice !== -1) {
                this.tareas.splice(tareaIndice, 1, { ...this.editarTareaData });
            }
            this.editDialog = false;
        },
        async traerTareas() {
            const response =await todo();
            this.tareas = response.data.data
       

        }
    },
    mounted() {
        this.traerTareas();
    }
}

</script>

<style scoped>
.v-container {
    /* max-width: 600px; */
    margin: 0 auto;
}
</style>
