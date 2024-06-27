import http from './utils/request'


export const todo = () => http({
    url: '/tarea/todo',
    method: 'get'
  })


export const addTarea = (data: any) => http({
    url: '/tarea',
    method: 'post',
    data
  })


export const updateTarea = (data: any) => http({
    url: '/tarea',
    method: 'put',
    data
  })


export const deleteTarea = (id: any) => http({
    url: '/tarea',
    method: 'delete',
    params: {
      id
    }
  })