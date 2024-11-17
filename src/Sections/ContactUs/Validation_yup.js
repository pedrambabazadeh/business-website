import * as Yup from 'yup';

// Form validation schema using Yup
const validationSchema = Yup.object({
    firstName: Yup.string().required('First Name is required'),
    lastName: Yup.string().required('Last Name is required'),
    email: Yup.string().email('Invalid email address').required('Email is required'),
    content: Yup.string().required('Message Content is required'),
    gdpr: Yup.boolean().oneOf([true], 'GDPR consent is required')
  });

  export default validationSchema