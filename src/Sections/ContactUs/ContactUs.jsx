import React from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { TextField, Button } from '@mui/material';

// Form validation schema using Yup
const validationSchema = Yup.object({
  name: Yup.string().required('Name is required'),
  email: Yup.string().email('Invalid email format').required('Email is required'),
  message: Yup.string().min(10, 'Message must be at least 10 characters').required('Message is required'),
});

const ContactUs = () => {
  return (
    <Formik
      initialValues={{ name: '', email: '', message: '' }}
      validationSchema={validationSchema}
      onSubmit={(values, { setSubmitting }) => {
        setTimeout(() => {
          console.log('Form Submitted', values);
          setSubmitting(false);
        }, 400);
      }}
    >
      {({ isSubmitting }) => (
        <Form>
          <div>
            <Field
              name="name"
              as={TextField}
              label="Name"
              variant="outlined"
              fullWidth
              margin="normal"
              helperText={<ErrorMessage name="name" />}
            />
          </div>
          <div>
            <Field
              name="email"
              as={TextField}
              label="Email"
              type="email"
              variant="outlined"
              fullWidth
              margin="normal"
              helperText={<ErrorMessage name="email" />}
            />
          </div>
          <div>
            <Field
              name="message"
              as={TextField}
              label="Message"
              variant="outlined"
              fullWidth
              multiline
              rows={4}
              margin="normal"
              helperText={<ErrorMessage name="message" />}
            />
          </div>
          <Button type="submit" variant="contained" color="primary" disabled={isSubmitting}>
            Submit
          </Button>
        </Form>
      )}
    </Formik>
  );
};

export default ContactUs;
