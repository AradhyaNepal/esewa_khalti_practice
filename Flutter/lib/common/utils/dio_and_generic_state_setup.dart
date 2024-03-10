import 'package:base_repository_bya2/export.dart';

void dioAndGenericStateSetup() {
  BaseRepositorySetup.init(
    errorWithMobileOnApiRequest: ()=>"Something went wrong. Please contact support team.",
    errorWithApiOnApiRequest: ()=>"Something went wrong. Please try again later.",
    token: ()=>"Token",
    onErrorHandleTokenExpiry: (_){},
    onResponseInterceptor: (_){},
  );
}
